using UnityEngine.UI;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Board board {get; private set;}
    public TetrominoData data {get; private set;}
    public Vector3Int[] cells {get; private set;}
    public Vector3Int position {get; private set;}
    public int rotationIndex {get; private set;}
    public Text Speed;
    public Text ScoreText;
    public Text SpeedText;
    public Text LineText;
    public Text HighscoreText;
    public Text Highscore;
    public Text Condition;
    private int speed = 1;
    private bool stop = true;
    public Button PlayButton;
    public Button Quit;
    public Button StopButton;
    public Button Left;
    public Button Right;
    public Button DownButton;
    public Button Rotate_Left;
    public Button Rotate_right;
    public RectTransform Level_complete;
    public int Complete;
    public SpriteRenderer Menu_Fon;
    public float Alfa = 1f;
    public float changespeed;
    public float changespeed1;
    public float changespeed2;
    public float changespeed3;
    public float changespeed4;
    public float stepDelay = 1f;
    public float lockDelay = 0.5f;

    private float stepTime;
    private float lockTime;
    public void Initialize(Board board, Vector3Int position, TetrominoData data)
    {
        this.board = board;
        this.position = position;
        this.data = data;
        this.rotationIndex = 0;
        this.stepTime = Time.time + this.stepDelay;
        this.lockTime = 0f;

        if (this.cells == null)
        {
            this.cells = new Vector3Int[data.cells.Length];
        }

        for (int i = 0; i < data.cells.Length; i++)
        {
            this.cells[i] = (Vector3Int)data.cells[i];
        }
    }
    private void Start() 
    {
        Highscore.text = PlayerPrefs.GetInt("best", 0).ToString();
    }
    private void Update() 
    {
        this.board.Score.text = "" + this.board.score;
        this.board.Line.text = "" + this.board.line;
        Speed.text = "" + speed;
        ScoreText.text = "Очки";
        LineText.text = "Линии";
        SpeedText.text = "Скорость";
        HighscoreText.text = "Рекорд";
        this.board.Clear(this); 

        if (this.board.score >= Complete)
        {
            Level_complete.localPosition = new Vector2(0, 0);
            Left.interactable = false;
            Right.interactable = false;
            DownButton.interactable = false;
            Rotate_Left.interactable = false;
            Rotate_right.interactable = false;
            Condition.enabled = false;
        }

        if(this.board.score > PlayerPrefs.GetInt("best", 0))
        {
            PlayerPrefs.SetInt("best", this.board.score);
            Highscore.text = this.board.score.ToString();
        }

        this.lockTime += Time.deltaTime;
        if (stop == true)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Rotate(-1);
            }else if (Input.GetKeyDown(KeyCode.E))
            {
                Rotate(1);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector2Int.left);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector2Int.right);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector2Int.down);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                HardDrop();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Stop();
            }
        }
        

        if (Time.time >= this.stepTime)
        {
            Step();
        }

        this.board.Set(this);

        if (this.board.score == changespeed)
        {
            stepDelay = 0.8f;
            Alfa = 0.8f;
            speed = 2;
        }
         if (this.board.score == changespeed1)
        {
            stepDelay = 0.6f;
            Alfa = 0.6f;
            speed = 3;
        }
         if (this.board.score == changespeed2)
        {
            stepDelay = 0.4f;
            Alfa = 0.4f;
            speed = 4;
        }
         if (this.board.score == changespeed3)
        {
            stepDelay = 0.2f;
            Alfa = 0.2f;
            speed = 5;
        }
         if (this.board.score == changespeed4)
        {
            stepDelay = 0.1f;
            Alfa = 0.1f;
            speed = 6;
        }
    }

    public void RotateLeft()
    {
        if (stop == true){
            this.board.Clear(this);
            Rotate(-1);
        }
    }

    public void RotateRight()
    {
        if (stop ==  true)
        {
            this.board.Clear(this);
            Rotate(1);
        }
        
    }

    public void MoveLeft()
    {
        if (stop == true)
        {
            this.board.Clear(this);
            Move(Vector2Int.left);
        }
        
    }
    public void MoveLRight()
    {
        if(stop == true)
        {
            this.board.Clear(this);
            Move(Vector2Int.right);
        }
        
    }

    public void Down()
    {
        if (stop == true)
        {
            this.board.Clear(this);
            HardDrop();
        }
        
    }
    private void Step()
    {
        this.stepTime = Time.time + this.stepDelay;

        Move(Vector2Int.down);

        if (this.lockTime >= this.lockDelay)
        {
            Lock();
        }
    }

    private void HardDrop()
    {
        while(Move(Vector2Int.down))
        {
            continue;
        }

        Lock();
    }
    
    private void Lock()
    {
        this.board.Set(this);

        this.board.ClearLines();
        this.board.SpawnPiece();
    }

    private bool Move(Vector2Int translatoin)
    {
        Vector3Int newPosition = this.position;
        newPosition.x += translatoin.x;
        newPosition.y += translatoin.y;

        bool valid = this.board.isValidPosition(this, newPosition);

        if (valid)
        {
            this.position = newPosition;
            this.lockTime = 0f;
        } 

        return valid;
    }

    private void Rotate (int direction)
    {
        int originalRotation = this.rotationIndex;
        this.rotationIndex += Wrap(this.rotationIndex + direction, 0, 4);

        ApplyRotationMatrix(direction);

        if (!TestWallKicks(this.rotationIndex, direction))
        {
            this.rotationIndex = originalRotation;
            ApplyRotationMatrix(-direction);
        }
    }  

    

    private void ApplyRotationMatrix(int direction)
    {
        for (int i = 0; i < this.cells.Length; i++)
        {
            Vector3 cell = this.cells[i];

            int x, y;

            switch(this.data.tetromino)
            {
                case Tetromino.I:
                case Tetromino.O:
                    cell.x -= 0.5f;
                    cell.y -= 0.5f;
                    x = Mathf.CeilToInt((cell.x * Data.RotationMatrix[0] * direction) + (cell.y * Data.RotationMatrix[1] * direction));
                    y = Mathf.CeilToInt((cell.x * Data.RotationMatrix[2] * direction) + (cell.y * Data.RotationMatrix[3] * direction));
                    break;

                default:
                    x = Mathf.RoundToInt((cell.x * Data.RotationMatrix[0] * direction) + (cell.y * Data.RotationMatrix[1] * direction));
                    y = Mathf.RoundToInt((cell.x * Data.RotationMatrix[2] * direction) + (cell.y * Data.RotationMatrix[3] * direction));
                    break;
            }

            this.cells[i] = new Vector3Int(x, y, 0);
        }
    }

    private bool TestWallKicks(int rotationIndex, int rotationDirection)
    {
        int wallKickIndex = GetWallKickIndex(rotationIndex, rotationDirection);

        for (int i = 0; i < this.data.wallKicks.GetLength(1); i++)
        {
            Vector2Int translation = this.data.wallKicks[wallKickIndex, i];
            {
                if (Move(translation))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private int GetWallKickIndex(int rotationIndex, int rotationDirection)
    {
        int wallKickIndex = rotationIndex * 2;

        if (rotationDirection < 0)
        {
            wallKickIndex--;
        }
        return Wrap(wallKickIndex, 0, this.data.wallKicks.GetLength(0));
    }

    private int Wrap(int input, int min, int max)
    {
        if (input < min)
        {
            return max - (min - input) % (max - min);
        } else {
            return min + (input - min) % (max - min);
        }
    }

    public void Stop()
    {
        stepDelay = 100000000000000000000000000000000000000f;
        stop = false;
        PlayButton.interactable = true;
        Quit.interactable = true;
        StopButton.interactable = false;
        Left.interactable = false;
        Right.interactable = false;
        DownButton.interactable = false;
        Rotate_Left.interactable = false;
        Rotate_right.interactable = false;
        Menu_Fon.enabled = true;
        ScoreText.enabled = false;
        SpeedText.enabled = false;
        LineText.enabled = false;
        Speed.enabled = false;
        HighscoreText.enabled = false;
        Highscore.enabled = false;
        this.board.Line.enabled = false;
        this.board.Score.enabled = false;
        Condition.enabled = false;
    }

    public void Play()
    {
        stepDelay = Alfa;
        stop = true;
        PlayButton.interactable = false;
        Quit.interactable = false;
        StopButton.interactable = true;
        Left.interactable = true;
        Right.interactable = true;
        DownButton.interactable = true;
        Rotate_Left.interactable = true;
        Rotate_right.interactable = true;
        Menu_Fon.enabled = false;
        ScoreText.enabled = true;
        SpeedText.enabled = true;
        LineText.enabled = true;
        Speed.enabled = true;
        HighscoreText.enabled = true;
        Highscore.enabled = true;
        this.board.Line.enabled = true;
        this.board.Score.enabled = true;
        Condition.enabled = true;
    }

}

using UnityEngine.Tilemaps;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    public Tilemap tilemap {get; private set;}
    public Piece activePiece {get; private set;}
    public TetrominoData[] tetrominoes;
    public Vector3Int spawnPosition;
    public Vector2Int boardSize = new Vector2Int(10, 20);
    public Text Score;
    public Text Line;
    public int line = 0;
    public int score = 0;
    public static bool Complete = false;
    public static bool Complete1 = false;
    public static bool Complete2 = false;
    public static bool Complete3 = false;
    public static bool Complete4 = false;
    public static bool Complete5 = false;
    public static bool Complete6 = false;
    public static bool Complete7 = false;
    public static bool Complete8 = false;
    public static bool Complete9 = false;
    public static bool Complete10 = false;
    public static bool Complete11 = false;
    public static bool Complete12 = false;
    public static bool Complete13 = false;
    public static bool Complete14 = false;
    public static bool Complete15 = false;
    public static bool Complete16 = false;
    public static bool Complete17 = false;
    

    public RectInt Bounds
    {
        get{
            Vector2Int position = new Vector2Int(-this.boardSize.x / 2, - this.boardSize.y / 2);
            return new RectInt(position, this.boardSize);
        }
    }
    private void Awake() 
    {
        this.tilemap = GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();

        for (int i = 0; i < this.tetrominoes.Length; i++)
        {
            this.tetrominoes[i].Initialize();
        }
    }

    private void Start() 
    {
        SpawnPiece();
    }

    public void SpawnPiece()
    {
        int random = Random.Range(0, this.tetrominoes.Length);
        TetrominoData data = this.tetrominoes[random];

        this.activePiece.Initialize(this, this.spawnPosition, data);

        if (isValidPosition(this.activePiece, this.spawnPosition))
        {
            Set(this.activePiece);
        } else {
            GameOver();
        }

        Set(this.activePiece);
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Level1_complete()
    {
        SceneManager.LoadScene(2);
        Complete = true;
    }
    public void Level2_complete()
    {
        SceneManager.LoadScene(2);
        Complete1 = true;
    }
    public void Level3_complete()
    {
        SceneManager.LoadScene(2);
        Complete2 = true;
    }
    public void Level4_complete()
    {
        SceneManager.LoadScene(2);
        Complete3 = true;
    }
    public void Level5_complete()
    {
        SceneManager.LoadScene(2);
        Complete4 = true;
    }
    public void Level6_complete()
    {
        SceneManager.LoadScene(2);
        Complete5 = true;
    }
    public void Level7_complete()
    {
        SceneManager.LoadScene(2);
        Complete6 = true;
    }
    public void Level8_complete()
    {
        SceneManager.LoadScene(2);
        Complete7 = true;
    }
    public void Level9_complete()
    {
        SceneManager.LoadScene(2);
        Complete8 = true;
    }
    public void Level10_complete()
    {
        SceneManager.LoadScene(2);
        Complete9 = true;
    }
    public void Level11_complete()
    {
        SceneManager.LoadScene(2);
        Complete10 = true;
    }
    public void Level12_complete()
    {
        SceneManager.LoadScene(2);
        Complete11 = true;
    }
    public void Level13_complete()
    {
        SceneManager.LoadScene(2);
        Complete12 = true;
    }
    public void Level14_complete()
    {
        SceneManager.LoadScene(2);
        Complete13 = true;
    }
    public void Level15_complete()
    {
        SceneManager.LoadScene(2);
        Complete14 = true;
    }
    public void Level16_complete()
    {
        SceneManager.LoadScene(2);
        Complete15 = true;
    }
    public void Level17_complete()
    {
        SceneManager.LoadScene(2);
        Complete16 = true;
    }
    public void Level18_complete()
    {
        SceneManager.LoadScene(2);
        Complete17 = true;
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePosition, piece.data.tile);
        }
    }

     public void Clear(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this.tilemap.SetTile(tilePosition, null);
        }
    }

    public bool isValidPosition(Piece piece, Vector3Int position)
    {
        RectInt bounds = this.Bounds;

        for (int i = 0; i <piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + position;

            if (!bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            if (this.tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }
        return true;
    }

    public void ClearLines()
    {
        RectInt bounds  = this.Bounds;
        int row = bounds.yMin;

        while (row < bounds.yMax)
        {
            if (IsLineFull(row)){
                LineClear(row);
            } else {
                row++;
            }
        }
    }
    private bool IsLineFull(int row)
    {
        RectInt bounds = this.Bounds;
        for(int col = bounds.xMin; col< bounds.xMax; col++)
        {
             Vector3Int position = new Vector3Int(col, row, 0);

            if (!this.tilemap.HasTile(position))
            {
                return false;
            }
        }
        return true;
    }

    private void LineClear(int row)
    {
        RectInt bounds = this.Bounds;

        for (int col = bounds.xMin; col < bounds.xMax; col++)
        {
            Vector3Int position = new Vector3Int(col, row, 0);
            this.tilemap.SetTile(position, null);
        }

        

        while (row < bounds.yMax)
        {
            for (int col = bounds.xMin; col < bounds.xMax; col++)
            {
                Vector3Int position = new Vector3Int(col, row + 1, 0);
                TileBase above = this.tilemap.GetTile(position);

                position = new Vector3Int(col, row, 0);
                this.tilemap.SetTile(position, above);
            }
            row++;
        }
        score += 100;
        line ++;
    }

    
        
            
        
}


using UnityEngine;
using UnityEngine.SceneManagement;


public class Grid2D : MonoBehaviour
{

    private bool primerturno;                    //Decalración de variable booleana
    public Color colorfondo;                     //Declaración de variable pública color fondo (color al mostrar las esferas)
    private GameObject[,] grid;                  //Declaración de variable privada de un objeto esfera
    public int height;                           //Declaración de variable pública de altura
    public int width;                            //Declaración de variable pública de ancho
    bool win;

   
    void Start()
    {
        grid = new GameObject[width, height];                                               //El objeto se ubica en una posición en altura y ancho
        for (int i = 0; i < width; i++)                                                     //Se inicia el ciclo de poner esferas a lo ancho
        {
            
            for (int j = 0; j < height; j++)                                                //Se inicia el ciclo de ponera esferas a lo alto
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);                  //Se almacena una un objeto tipo esfera
                go.transform.position= new Vector3(i,j,0);                                  //La esfera almacenada se ubica enuna posición en el vector 3
                grid[i,j]=go;                                                               //Coordenadas del objeto en x ,y

                go.GetComponent<Renderer>().material.color = colorfondo;                    //Se crea un material de tipo color

                grid[i, j] = go;                                                            //El objeto grid es igual al a la variable go
            }

        }
    }

    void Update()
    {
        Vector3 mPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);           //Posición de la cámara en vector 3
        


        if (Input.GetKey(KeyCode.Mouse0)&& win==false)                                     //La cámara ubica la posición del mouse
        {
            UpdatePickedPiece(mPosition);
        }
    }


    void UpdatePickedPiece(Vector3 position)
    {
        int i = (int)(position.x + 0.5f);                                                   //Variable i se ubica en una pocicion x
        int j = (int)(position.y + 0.5f);                                                   //Variable j se ubica en una pocicion y

        if (Input.GetButtonDown("Fire1"))
        {
            if (i >= 0 && j >= 0 && i < width && j< height)                                 //Variable i y variable j se ubican a lo ancho y a lo alto
            {
                GameObject go=grid[i,j];                                                    //El objeto se pone en el espacio i y en el j
                if (go.GetComponent<Renderer>().material.color == colorfondo)               //Se renderiza el color del fondo
                {
                    Color colorAUsar = Color.clear;
                    if (primerturno)
                    colorAUsar = Color.blue;

                    else
                    colorAUsar = Color.red;

                    go.GetComponent<Renderer>().material.color = colorAUsar;
                    primerturno = !primerturno;
                    VerificadorX(i, j, colorAUsar);
                    VerificadorY(i, j, colorAUsar);
                    DiagoPositiva(i, j, colorAUsar);
                    DiagoNegativa(i, j, colorAUsar);
                  

                }
            }
        }
    }
      public void VerificadorX(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        for (int i = x-3; i <= x+3; i++)
        {
            if (i < 0 || i >= width)
                continue;

            GameObject go = grid[i, y];

            if (go.GetComponent<Renderer>().material.color == colorVerificar)
            {
                contador++;
                if (contador == 4 && colorVerificar == Color.blue)
                {
                    Debug.Log("Gana el Player 2");
                    win = true;
                    SceneManager.LoadScene(2);
                    
                    

                }
                else if (contador == 4 && colorVerificar == Color.red)
                {
                    Debug.Log("Gana el Player 1");
                    win = true;
                    SceneManager.LoadScene(3);
                }
            }
            else
                contador = 0;
        }
    }

    public void VerificadorY(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        for (int j = y - 3; j <= y + 3; j++)
        {
            if (j < 0 || j >= height)
                continue;

            GameObject go = grid[x, j];

            if (go.GetComponent<Renderer>().material.color == colorVerificar)
            {
                contador++;
                if (contador == 4 && colorVerificar ==Color.blue)
                {
                    Debug.Log("Gana el player 2");
                    win = true;
                    SceneManager.LoadScene(2);
                }
                else if (contador == 4 && colorVerificar == Color.red)
                {
                    Debug.Log("Gana el Player 1");
                    win = true;
                    SceneManager.LoadScene(3);
                }
            }
            else
                contador = 0;
        }
    }

    public void DiagoPositiva(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        int j = y - 4;


        for (int i = x - 3; i <= x + 3; i++ )
        {
            j++;
            if (j < 0 || j >= height || i < 0 || i >= width)
                continue;

                GameObject go =grid[i, j];
               
               // Debug.Log(go.GetComponent<Renderer>().material.color);
                // Debug.Log(colorAVerificando);
                if (go.GetComponent<Renderer>().material.color == colorVerificar)
                {
                    contador++;
                    if (contador == 4 && colorVerificar ==Color.blue)
                    {
                        Debug.Log("Gana el player 2");
                        win = true;
                    SceneManager.LoadScene(2);
                }
                    else if (contador == 4 && colorVerificar == Color.red)
                {
                    Debug.Log("Gana el Player 1");
                    win = true;
                    SceneManager.LoadScene(3);
                }
                }
                else
                    contador = 0;
           // Debug.Log(contador);
        }
    }


    public void DiagoNegativa(int x, int y, Color colorVerificar)
    {
        int contador = 0;
        int j = y + 4;


        for (int i = x - 3; i <= x + 3; i++)
        {
            j--;

            if (j < 0 || j >= height || i < 0 || i >= width)
                continue;

            GameObject go = grid[i, j];

            if (go.GetComponent<Renderer>().material.color == colorVerificar)
            {
                contador++;
                if (contador == 4 && colorVerificar == Color.blue)
                {
                    Debug.Log("Gana el player 2");
                    win = true;
                    SceneManager.LoadScene(2);
                }
                else if (contador == 4 && colorVerificar == Color.red)
                {
                    Debug.Log("Gana el Player 1");
                    win = true;
                    SceneManager.LoadScene(3);
                }
            }
            else
                contador = 0;

        }
    }

}

     
     


    


  
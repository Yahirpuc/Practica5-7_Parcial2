using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PracticasWinForms
{
    public class Form1 : Form
    {
        // Diccionario con listas enlazadas para almacenar las palabras por letra
        Dictionary<char, List<string>> palabrasPorLetra = new Dictionary<char, List<string>>();


        // Lista doblemente enlazada para almacenar las palabras invertidas
        LinkedList<string> palabrasInvertidas = new LinkedList<string>();

        // Lista circular para los resultados de palíndromos
        CircularList<string> resultadosPalindromos = new CircularList<string>();

        // Componentes de la UI
        private MenuStrip menuStrip1;
        private ToolStripMenuItem practica5ToolStripMenuItem;
        private ToolStripMenuItem practica6ToolStripMenuItem;
        private ToolStripMenuItem practica7ToolStripMenuItem;
        private TextBox textBoxInput;
        private Button buttonAddWord;
        private Button buttonInvertWord;
        private Button buttonCheckPalindrome;
        private Button buttonClearWords;
        private Button buttonClearInvertidos;
        private Button buttonClearPalindromos;
        private ListBox listBoxOutput;
        private Label labelTitle;
        private Label labelOutput;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Crear componentes de la interfaz de usuario

            this.menuStrip1 = new MenuStrip();
            this.practica5ToolStripMenuItem = new ToolStripMenuItem();
            this.practica6ToolStripMenuItem = new ToolStripMenuItem();
            this.practica7ToolStripMenuItem = new ToolStripMenuItem();
            this.textBoxInput = new TextBox();
            this.buttonAddWord = new Button();
            this.buttonInvertWord = new Button();
            this.buttonCheckPalindrome = new Button();
            this.buttonClearWords = new Button();
            this.buttonClearInvertidos = new Button();
            this.buttonClearPalindromos = new Button();
            this.listBoxOutput = new ListBox();
            this.labelTitle = new Label();
            this.labelOutput = new Label();

            // Formulario
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Práctica 5-7";

            // MenuStrip
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
                this.practica5ToolStripMenuItem,
                this.practica6ToolStripMenuItem,
                this.practica7ToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.Controls.Add(this.menuStrip1);

            
            this.practica5ToolStripMenuItem.Text = "Práctica 5: Listar por Letra";
            this.practica6ToolStripMenuItem.Text = "Práctica 6: Invertir Palabra";
            this.practica7ToolStripMenuItem.Text = "Práctica 7: Verificar Palíndromo";

            this.practica5ToolStripMenuItem.Click += new EventHandler(this.Practica5Menu_Click);
            this.practica6ToolStripMenuItem.Click += new EventHandler(this.Practica6Menu_Click);
            this.practica7ToolStripMenuItem.Click += new EventHandler(this.Practica7Menu_Click);

           
            this.labelTitle.Text = "Prácticas 5-7";
            this.labelTitle.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(200, 30);
            this.labelTitle.Size = new System.Drawing.Size(400, 40);
            this.Controls.Add(this.labelTitle);

            this.textBoxInput.Location = new System.Drawing.Point(50, 100);
            this.textBoxInput.Size = new System.Drawing.Size(300, 30);
            this.Controls.Add(this.textBoxInput);

          
            this.buttonAddWord.Text = "Agregar Palabra";
            this.buttonAddWord.Location = new System.Drawing.Point(50, 150);
            this.buttonAddWord.Size = new System.Drawing.Size(150, 40);
            this.buttonAddWord.Click += new EventHandler(this.buttonAddWord_Click);
            this.Controls.Add(this.buttonAddWord);

          
            this.buttonInvertWord.Text = "Invertir Palabra";
            this.buttonInvertWord.Location = new System.Drawing.Point(50, 150);
            this.buttonInvertWord.Size = new System.Drawing.Size(150, 40);
            this.buttonInvertWord.Click += new EventHandler(this.buttonInvertWord_Click);
            this.buttonInvertWord.Visible = false;
            this.Controls.Add(this.buttonInvertWord);

            this.buttonCheckPalindrome.Text = "Verificar Palíndromo";
            this.buttonCheckPalindrome.Location = new System.Drawing.Point(50, 150);
            this.buttonCheckPalindrome.Size = new System.Drawing.Size(150, 40);
            this.buttonCheckPalindrome.Click += new EventHandler(this.buttonCheckPalindrome_Click);
            this.buttonCheckPalindrome.Visible = false;
            this.Controls.Add(this.buttonCheckPalindrome);

         
            this.buttonClearWords.Text = "Limpiar Lista";
            this.buttonClearWords.Location = new System.Drawing.Point(210, 150);
            this.buttonClearWords.Size = new System.Drawing.Size(150, 40);
            this.buttonClearWords.Click += new EventHandler(this.buttonClearWords_Click);
            this.Controls.Add(this.buttonClearWords);

           
            this.buttonClearInvertidos.Text = "Limpiar Invertidos";
            this.buttonClearInvertidos.Location = new System.Drawing.Point(210, 150);
            this.buttonClearInvertidos.Size = new System.Drawing.Size(150, 40);
            this.buttonClearInvertidos.Click += new EventHandler(this.buttonClearInvertidos_Click);
            this.buttonClearInvertidos.Visible = false;
            this.Controls.Add(this.buttonClearInvertidos);

          
            this.buttonClearPalindromos.Text = "Limpiar Palíndromos";
            this.buttonClearPalindromos.Location = new System.Drawing.Point(210, 150);
            this.buttonClearPalindromos.Size = new System.Drawing.Size(150, 40);
            this.buttonClearPalindromos.Click += new EventHandler(this.buttonClearPalindromos_Click);
            this.buttonClearPalindromos.Visible = false;
            this.Controls.Add(this.buttonClearPalindromos);

          
            this.listBoxOutput.Location = new System.Drawing.Point(400, 100);
            this.listBoxOutput.Size = new System.Drawing.Size(350, 300);
            this.listBoxOutput.HorizontalScrollbar = true; // Activar barra de desplazamiento horizontal
            this.Controls.Add(this.listBoxOutput);

          
            this.labelOutput.Location = new System.Drawing.Point(50, 200);
            this.labelOutput.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(this.labelOutput);
        }

        // Práctica 5: Listar palabras por letra
        private void buttonAddWord_Click(object sender, EventArgs e)
        {
         
            string palabra = textBoxInput.Text;

          
            if (!string.IsNullOrWhiteSpace(palabra))
            {
                // Aqui obtiene la primera letra
                char letraInicial = palabra[0];

                // Si no hay una lista para esa letra, la crea.
                if (!palabrasPorLetra.ContainsKey(letraInicial))
                {
                    palabrasPorLetra[letraInicial] = new List<string>();
                }

                // Agrega la palabra a la lista de esa letra.
                palabrasPorLetra[letraInicial].Add(palabra);

                // Actualiza con las palabras agrupadas por letra.
                listBoxOutput.Items.Clear();
                foreach (var key in palabrasPorLetra.Keys)
                {
                    listBoxOutput.Items.Add($"Letra {key}: {string.Join(", ", palabrasPorLetra[key])}");
                }
            }
        }


        // Práctica 5: Limpiar la lista
        private void buttonClearWords_Click(object sender, EventArgs e)
        {
            palabrasPorLetra.Clear();
            listBoxOutput.Items.Clear();
        }

        // Práctica 6: Invertir palabra.
        private void buttonInvertWord_Click(object sender, EventArgs e)
        {
           
            string palabra = textBoxInput.Text;

           
            if (!string.IsNullOrWhiteSpace(palabra))
            {
                // Aqui se crea una nueva lista enlazada para almacenar los caracteres de la palabra.
                LinkedList<char> listaCaracteres = new LinkedList<char>();

                // Recorre cada letra de la palabra y lo añade a la lista enlazada.
                foreach (char c in palabra)
                {
                    listaCaracteres.AddLast(c);
                }

                // Crea una lista enlazada para almacenar los caracteres en orden invertido.
                LinkedList<char> listaInvertida = new LinkedList<char>();

                // Obtiene el último nodo de la lista de caracteres para comenzar la inversión.
                var nodo = listaCaracteres.Last;

                // Recorre la lista desde el último nodo hasta el primero, añadiendo cada carácter a la lista invertida.
                while (nodo != null)
                {
                    listaInvertida.AddLast(nodo.Value); // Añade el valor del nodo actual a la lista invertida.
                    nodo = nodo.Previous; // Se mueve al nodo anterior.
                }

                // Aqui convierte la lista enlazada en un string.
                string palabraInvertida = new string(listaInvertida.Select(c => c).ToArray());

                // Agrega el resultado de la inversión a una lista de historial de palabras invertidas.
                palabrasInvertidas.AddLast($"Palabra: {palabra} -> Invertida: {palabraInvertida}");

               
                listBoxOutput.Items.Clear();

                // Recorre la lista de palabras invertidas.
                foreach (var invertida in palabrasInvertidas)
                {
                    listBoxOutput.Items.Add(invertida);
                }
            }
        }


        // Práctica 6: Limpiar resultados de palabras invertidas
        private void buttonClearInvertidos_Click(object sender, EventArgs e)
        {
            palabrasInvertidas.Clear();
            listBoxOutput.Items.Clear();
        }

        // Práctica 7: Verificar si es palíndromo y guardar resultado
        private void buttonCheckPalindrome_Click(object sender, EventArgs e)
        {
           
            string palabra = textBoxInput.Text.ToLower();

            
            if (!string.IsNullOrWhiteSpace(palabra))
            {
                // Crea una nueva lista enlazada para almacenar los caracteres de la palabra.
                LinkedList<char> listaCaracteres = new LinkedList<char>();

                // Recorre cada carácter de la palabra y lo añade a la lista enlazada.
                foreach (char c in palabra)
                {
                    listaCaracteres.AddLast(c);
                }

                //Verifca si es palindromo o no
                bool esPalindromo = true;

                // Obtiene el primer y el último nodo de la lista enlazada.
                var nodoInicio = listaCaracteres.First;
                var nodoFin = listaCaracteres.Last;

                // Compara los caracteres desde el inicio y el final hacia el centro de la lista.
                while (nodoInicio != null && nodoFin != null && nodoInicio != nodoFin && nodoInicio.Previous != nodoFin)
                {
                    // Si los caracteres no coinciden, establece 'esPalindromo' en false y sale del bucle.
                    if (nodoInicio.Value != nodoFin.Value)
                    {
                        esPalindromo = false;
                        break;
                    }
                    // Avanza el nodo de inicio al siguiente carácter y el nodo de fin al carácter anterior.
                    nodoInicio = nodoInicio.Next;
                    nodoFin = nodoFin.Previous;
                }

               
                string resultado = esPalindromo ? "Es un palíndromo" : "No es un palíndromo";

                
                resultadosPalindromos.Add($"Palabra: {palabra} -> Resultado: {resultado}");

                listBoxOutput.Items.Clear();

                // Recorre la lista de resultados de palíndromos.
                foreach (var resultadoPalindromo in resultadosPalindromos)
                {
                    listBoxOutput.Items.Add(resultadoPalindromo);
                }
            }
        }


        // Práctica 7: Limpiar resultados de palíndromos
        private void buttonClearPalindromos_Click(object sender, EventArgs e)
        {
            resultadosPalindromos.Clear();
            listBoxOutput.Items.Clear();
        }

        // Menu actions
        private void Practica5Menu_Click(object sender, EventArgs e)
        {
            buttonAddWord.Visible = true;
            buttonClearWords.Visible = true;
            buttonInvertWord.Visible = false;
            buttonClearInvertidos.Visible = false;
            buttonCheckPalindrome.Visible = false;
            buttonClearPalindromos.Visible = false;
        }

        private void Practica6Menu_Click(object sender, EventArgs e)
        {
            buttonAddWord.Visible = false;
            buttonClearWords.Visible = false;
            buttonInvertWord.Visible = true;
            buttonClearInvertidos.Visible = true;
            buttonCheckPalindrome.Visible = false;
            buttonClearPalindromos.Visible = false;
        }

        private void Practica7Menu_Click(object sender, EventArgs e)
        {
            buttonAddWord.Visible = false;
            buttonClearWords.Visible = false;
            buttonInvertWord.Visible = false;
            buttonClearInvertidos.Visible = false;
            buttonCheckPalindrome.Visible = true;
            buttonClearPalindromos.Visible = true;
        }

        // Clase auxiliar para la lista circular
        public class CircularList<T> : LinkedList<T>
        {
            public new void Add(T item)
            {
                AddLast(item);
            }

            public new IEnumerator<T> GetEnumerator()
            {
                var node = this.First;

                if (node == null)
                    yield break; // Si no hay elementos, salir del enumerador

                do
                {
                    yield return node.Value;
                    node = node.Next ?? this.First; // Si llegas al final, vuelve al primer nodo
                }
                while (node != this.First); // Continuar hasta que volvamos al principio
            }

        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

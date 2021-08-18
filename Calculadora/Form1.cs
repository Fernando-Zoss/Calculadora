using System;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private double num1;
        private double num2;
        private string op;
        private bool PressionouIgual;
        private double resultado;

        private void Form1_Load(object sender, EventArgs e)
        {
            limparCampos();
        }

        // Função dos operadores
        private void limparCampos()
        {
            txtDisplay.Clear();
            num1 = 0;
            num2 = 0;
            resultado = 0;
            op = string.Empty;
            PressionouIgual = false;
        }

        // Adiciona caracter no display caso exista somente o 0 o mesmo é limpo do campo.
        private void AdicionarValorNumerico(string valor)
        {
            if (PressionouIgual == true)
            {
                txtDisplay.Clear();
                PressionouIgual = false;
            }
            if (txtDisplay.Text.Trim().Equals("0"))
            {
                txtDisplay.Text = valor;
            }
            else
            {
                txtDisplay.Text += valor;
            }

        }

        // Adiciona o caracter do display a variável op caso exista.
        private void AdicionarCaracterOp(string caracter)
        {
            if (!txtDisplay.Text.Trim().Equals(string.Empty))
            {
                if (txtDisplay.Text.Trim().Contains("."))
                {
                    num1 = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                }
                else
                {
                    num1 = Convert.ToDouble(txtDisplay.Text.Trim());
                }
                op = caracter;
                txtDisplay.Clear();
            }
            else
            {
                MessageBox.Show("É nescessário inserir um dídito antes de uma operação !");
            }
        }

        private void Calcular()
        {
            switch (op)
            {
                case "/":
                    if (num2 == 0)
                    {
                        MessageBox.Show("Digite um número diferente de 0");
                        break;
                    }
                    resultado = (num1 / num2);
                    break;

                case "*":
                    resultado = (num1 * num2);
                    break;

                case "-":
                    resultado = (num1 - num2);
                    break;

                case "+":
                    resultado = (num1 + num2);
                    break;

                case "^":
                    resultado = CalcularPotencia();
                    break;
            }

            txtDisplay.Text = resultado.ToString().Replace(",",".");
        }

        public double CalcularPotencia()
        {
            return Math.Pow(num1, num2);
            
        }

        /*---------------------------------------------------------------------------*/
        private void btn0_Click(object sender, EventArgs e)
        {
            AdicionarValorNumerico("0");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AdicionarValorNumerico("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AdicionarValorNumerico("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AdicionarValorNumerico("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AdicionarValorNumerico("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AdicionarValorNumerico("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AdicionarValorNumerico("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AdicionarValorNumerico("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AdicionarValorNumerico("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AdicionarValorNumerico("9");
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            AdicionarCaracterOp("/");
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            AdicionarCaracterOp("*");

        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            AdicionarCaracterOp("-");

        }

        private void btnAdicao_Click(object sender, EventArgs e)
        {
            AdicionarCaracterOp("+");

        }

        private void btnIgualdade_Click(object sender, EventArgs e)
        {
            if (PressionouIgual)
            {
                txtDisplay.Clear();
                PressionouIgual = false;
                return;
            }
            if (!txtDisplay.Text.Trim().Equals(String.Empty)) 
            {
                if (txtDisplay.Text.Trim().Contains("."))
                {
                    num2 = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                } else {
                            num2 = Convert.ToDouble(txtDisplay.Text.Trim());
                       }
                Calcular();
                PressionouIgual = true;
            }
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            if (PressionouIgual)
            {
                txtDisplay.Text = "0.";
                PressionouIgual = false;
                return;
            };
            if (txtDisplay.Text.Trim().Equals(String.Empty)) txtDisplay.Text = "0";
            if (txtDisplay.Text.Trim().Contains(".")) return;
            txtDisplay.Text = txtDisplay.Text + ".";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            if (op.Equals(String.Empty) || PressionouIgual)
            {
                limparCampos();
            }
            else
            {
                txtDisplay.Clear();
            }
        }

        private void btnMaisMenos_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Trim().Equals(String.Empty))
            {
                txtDisplay.Text = (Convert.ToDouble(txtDisplay.Text.Trim().Replace(".",",")) * (-1)).ToString().Replace(",", ".");
            }
        }

        private void btnRenoveUltimoDigito_Click(object sender, EventArgs e)
        {
            int qtdCaracteres = txtDisplay.Text.Trim().Length;
            String conteudoTexto = txtDisplay.Text.Trim();
            txtDisplay.Clear();
            
            // Manipula a string como uma cadeia de caracteres
            for (int i = 0; i < qtdCaracteres - 1; i++)
                txtDisplay.Text = txtDisplay.Text + conteudoTexto[i];
        }

        private void btnQuadrado_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Trim().Equals(String.Empty))
            {
                num1 = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                num2 = 2;
                var result = CalcularPotencia();
                txtDisplay.Text = result.ToString().Replace(",", ".");
                PressionouIgual = true;
            }
        }

        private void btnMultipicacao_Click(object sender, EventArgs e)
        {
            AdicionarCaracterOp("^");
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
            resultado = Math.Sqrt(num1);
            txtDisplay.Text = resultado.ToString().Replace(",", ".");
            PressionouIgual = true;
        }

        private void btnPorcentagem_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Trim().Equals(String.Empty))
            {
                num1 = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                if (num1 == 0)
                {
                    MessageBox.Show("Erro. Divisão por zero!");
                    return;
                }
                num1 = 1 / num1;
                var result = CalcularPotencia();
                txtDisplay.Text = result.ToString().Replace(",", ".");
                PressionouIgual = true;
            }
        }
    }
}
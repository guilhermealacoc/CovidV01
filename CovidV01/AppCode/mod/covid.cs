

namespace CovidV01.AppCode.mod
{
    public class covid
    {
        //attributes / CTRL + R + E
        private int _idUsuario;
        private string _nome;
        private string _telefone;
        private string _rua;
        private string _numero;
        private string _complemento;
        private string _bairro;
        private string _celular;
        private int _moradoresResidencia;
        private string _profissao;
        private int _idade;

        //constructor
        public covid()
        {
        }

        //getters/setters
        public int idUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string nome { get => _nome; set => _nome = value; }
        public string telefone { get => _telefone; set => _telefone = value; }
        public string rua { get => _rua; set => _rua = value; }
        public string numero { get => _numero; set => _numero = value; }
        public string complemento { get => _complemento; set => _complemento = value; }
        public string bairro { get => _bairro; set => _bairro = value; }
        public string celular { get => _celular; set => _celular = value; }
        public int moradoresResidencia { get => _moradoresResidencia; set => _moradoresResidencia = value; }
        public string profissao { get => _profissao; set => _profissao = value; }
        public int idade { get => _idade; set => _idade = value; }
    }
}

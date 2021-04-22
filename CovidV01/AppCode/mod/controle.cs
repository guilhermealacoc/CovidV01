namespace CovidV01.AppCode.mod
{
    public class controle
    {
        private int _idControle;
        private int _idUsuario;
        private int _idTeste;
        private string _status;
        private string _resultado;
        
        public controle()
        {
        }

        public int idControle { get => _idControle; set => _idControle = value; }
        public int idUsuario { get => _idUsuario; set => _idUsuario = value; }
        public int idTeste { get => _idTeste; set => _idTeste = value; }
        public string status { get => _status; set => _status = value; }
        public string resultado { get => _resultado; set => _resultado = value; }
    }
}

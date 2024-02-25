namespace Utils.SimpleExtensions
{
    public class ExceptionExtension : Exception
    {
        public string MsgSistema { get; set; }

        public ExceptionExtension(string MsgSistema, string? Message = null) : base(Message ?? MsgSistema)
        {
            this.MsgSistema = MsgSistema;
        }

        public ExceptionExtension(string MsgSistema, string Message, Exception exc) : base(Message, exc)
        {
            this.MsgSistema = MsgSistema;
        }
    }
}

namespace ALertMe
{
    public interface IClock
    {

        Clocks SetWatch();
        bool MsgAlert(Clocks clocks);

        
    }
}
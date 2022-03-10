using System;

namespace ExceptionEntities2
{
    public class WrongLoginPasswordException : Exception
    {
        public WrongLoginPasswordException() : base("Неверный логин или пароль") { }
    }

}

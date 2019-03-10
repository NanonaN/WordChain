using System;

namespace WordChain
{
    public class ProgramException : ApplicationException
    {
        public ProgramException(string message) : base(message)
        {

        }
    }
    public class ModeNotProvidedException : ProgramException
    {
        public ModeNotProvidedException(string message) : base(message)
        {

        }
    }
    public class ArgumentErrorException : ProgramException
    {
        public ArgumentErrorException(string message) : base(message)
        {

        }
    }
    public class FileException : ProgramException
    {
        public FileException(string message) : base(message)
        {

        }
    }
    public class InputFileException : FileException
    {
        public InputFileException(string message) : base(message)
        {

        }
    }
    public class FileNotReadableException : FileException
    {
        public FileNotReadableException(string message) : base(message)
        {

        }
    }
    public class FileNotWritableException : FileException
    {
        public FileNotWritableException(string message) : base(message)
        {

        }
    }
    public class WordRingException : ProgramException
    {
        public WordRingException(string message) : base(message)
        {

        }
    }
}

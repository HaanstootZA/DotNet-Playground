using System;

namespace MusicRenamer
{
    class NodeExistsException : Exception 
    {
        public NodeExistsException(string message) :
            base(message) { }

        public NodeExistsException() :
            base("Error Importing file") { } }

    class Import_Exception : Exception 
    {
        public Import_Exception(string message) :
            base(message) { }

        public Import_Exception() :
            base("Error Importing file") { } }

    class Naming_Exception :Exception
    {
        public Naming_Exception(string message) :
            base(message) { }

        public Naming_Exception() :
            base("The naming convention must contain at least one of the naming Tags") { }
    }

    class Renaming_Exception : Exception
    {
        public Renaming_Exception(string message) :
            base(message) { }
    }
}

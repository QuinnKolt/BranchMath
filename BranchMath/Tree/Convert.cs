using System;
using System.Collections.Generic;
using ValueType = BranchMath.Math.Value.ValueType;

namespace BranchMath.Tree {
    public static class Convert {
        public static List<ConversionRule<ValueType>> rules = new List<ConversionRule<ValueType>>();

        private static string strip(string r) {
            throw new NotImplementedException();
        }
        

        /// <summary>
        /// Creates a node assuming the string is of the form parts[0] ? ? parts[1] ? ? parts[2] ...,
        /// where ? corresponds to the type of modifier included.
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Node<ValueType> ReadLaTeX(string r) {
            throw new NotImplementedException();
        }
    }
}
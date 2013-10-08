using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcKissApplication.Models
{
    public class Node
    {

        public object data { get; set; }
        public ICollection<Node> _children = new HashSet<Node>();
        public ICollection<Node> children 
        { 
            get { return _children; }
            set { _children = value; }
        }

        public Node() { }

    }
}
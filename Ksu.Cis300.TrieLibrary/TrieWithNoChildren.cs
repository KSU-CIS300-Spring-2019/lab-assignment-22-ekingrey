/*TrieWithNoChild.cs
 * Author: Ehtan Kingrey
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {

        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString = false;
        
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmptyString);
            }

            

        }

        public bool Contains(string s)
        {
            if(s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                return false;
            }
            
        }
    }
}

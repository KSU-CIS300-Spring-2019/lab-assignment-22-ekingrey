/*TrieWithOneChild.cs
 * Author: Ehtan Kingrey
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// stores the only child
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// stores the label
        /// </summary>
        private char _lable;


        public TrieWithOneChild(string s, bool empty)
        {

            if(s == "" || (s[0]<'a' || s[0] > 'z'))
            {

                throw new ArgumentException();

            }
            else
            {

                _hasEmptyString = empty;
                _lable = s[0];
                _child = new TrieWithNoChildren().Add(s.Substring(1));

            }

        }

        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else if (s[0] ==_lable)
            {

               _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {

                return new TrieWithManyChildren(s, _hasEmptyString, _lable, _child);
            }
        }

        public bool Contains(string s)
        {
            if(s == "")
            {
                return _hasEmptyString;
            }
            else if (( s[0]==_lable))
            {

                return _child.Contains(s.Substring(1));

            }
            else
            {

                return false;
            }
        }
    }
}

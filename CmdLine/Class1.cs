
    //CmdLine v1.1, and CmdLineParser class - For Parsing command line options
    //Copyright (C) 2011 Ryan Whitworth (lithron@gmail.com; me@ryanwhitworth.com)

    //This program is free software: you can redistribute it and/or modify
    //it under the terms of the GNU General Public License as published by
    //the Free Software Foundation, either version 3 of the License, or
    //(at your option) any later version.

    //This program is distributed in the hope that it will be useful,
    //but WITHOUT ANY WARRANTY; without even the implied warranty of
    //MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    //GNU General Public License for more details.

    //You should have received a copy of the GNU General Public License
    //along with this program.  If not, see <http://www.gnu.org/licenses/>.

    //Please contact the author if you wish to see this library released under
    //a different licensing scheme.

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace CmdLine
{
    public class CmdLineParser
    {
        private ArrayList p_al = new ArrayList();
        private String p_cmdline = String.Empty;

        public String cmdline 
        {
            get
            {
                return p_cmdline;
            }
            set
            {
                p_cmdline = value.ToString();
                parse_regex(p_cmdline);
            }
        }
        public ArrayList commands
        {
            get
            {
                return p_al;
            }
            set
            {
                Exception blah = new Exception("Cannot set 'CmdLineParser.commands' property.  Only get supported");
                throw (blah);
            }
        }
        
        public CmdLineParser()
        {
        }
        public CmdLineParser(String data)
        {
            //parse(data);
            parse_regex(data);
        }

        // v1.1 now with more regex!
        private void parse_regex(String data)
        {
            String d = data;
            Regex r = null;
            MatchCollection m = null;

            // \x22 == double quote character == "
            // match double quote, any characater, double quote
            // double quote, forward slash, backslash, and bunches of other characters
            // are reserved in NTFS, FAT-32, and other MS operating systems.
            // http://msdn.microsoft.com/en-us/library/aa365247(v=vs.85).aspx for more details.
            r = new Regex(@"([\-\/])([\w]{1,4})=\x22[^\x22]{1,100}\x22");
            m = r.Matches(d);
            foreach (var item in m)
            {
                d = d.Remove(d.IndexOf(item.ToString()), item.ToString().Length);
                p_al.Add(item.ToString().Trim());
            }

            while (d.Contains("  "))
            {
                d = d.Replace("  ", " ");
            }

            r = new Regex(@"([\-\/])([\w]{1,4}) ");
            m = r.Matches(d);
            foreach (var item in m)
            {
                d = d.Remove(d.IndexOf(item.ToString()), item.ToString().Length);
                p_al.Add(item.ToString().Trim());
            }

            r = new Regex(@"([\-\/])([\w]{1,4})=[\w]{1,100}");
            m = r.Matches(d);
            foreach (var item in m)
            {
                d = d.Remove(d.IndexOf(item.ToString()), item.ToString().Length);
                p_al.Add(item.ToString().Trim());
            }

            // pull out alone last variables with no trailing spaces
            r = new Regex(@"([\-\/])([\w]{1,4})");
            m = r.Matches(d);
            foreach (var item in m)
            {
                d = d.Remove(d.IndexOf(item.ToString()), item.ToString().Length);
                p_al.Add(item.ToString().Trim());
            }

            for (int i = 0; i < p_al.Count; i++)
            {
                d = p_al[i].ToString();
                while ((d[0] == '-') || (d[0] == '/'))
                {
                    d = d.Substring(1, d.Length - 1);
                }
                p_al[i] = d;
            }
            int qqqq = 0;
        }
        // v1.0 used the parsing below..
        // no support for "long file names.dat"
        //private void parse(String data)
        //{
        //    String d = data;
        //    d = d.Trim();

        //    while (d.Contains(" "))
        //    {
        //        int space = d.IndexOf(" ");
        //        String qq = d.Substring(0, space);
        //        p_al.Add(qq);
        //        d = d.Substring(space, d.Length - space);
        //        d = d.Trim();
        //    }

        //    // grab last item in string
        //    if (d.Length != 0)
        //    {
        //        p_al.Add(d);
        //    }

        //    // remove any leading dashes
        //    // -t --t ---t ----t are all equal to "t"
        //    for (int i = 0; i < p_al.Count; i++)
        //    {
        //        d = p_al[i].ToString();
        //        while (d[0] == '-')
        //        {
        //            d = d.Substring(1, d.Length - 1);
        //        }
        //        p_al[i] = d;
        //    }

        //}
    }
}

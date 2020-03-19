using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MappingApplication
{
    class Page
    {
        private string m_title;
        private string m_url;

        public string Title { get { return m_title; } }
        public string URL { get { return m_url; } }

        public Page(string URL)
        {
            m_url = URL;
            m_title = GetTitleFromURL(URL);
        }

        private string GetTitleFromURL(string URL){
            return URL;
        }

        public Page() { }

        public Page[] GetLinks()
        {
            int val = /*MapMath.NODES;*/MapMath.RAND.Next(1, MapMath.NODES);
            Page[] links = new Page[val];
            for (int i = 0; i < val; i++)
            {
                links[i] = new Page(m_url + " " + i.ToString());
            }
            return links;
        }
    }
}

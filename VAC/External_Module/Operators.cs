﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace External_module
{
    public abstract class Operators : Working_data
    {
        static int count_of_operator4s_index = 1;
       protected int count_of_up_connection;
       protected int index_of_Operator;
        public string name_of_operators;

        protected List<Working_data> up_connection = new List<Working_data>();
        List<if_operator> if_Operators = new List<if_operator>();

        public override bool isUpcoonection
        {
            get
            {
                return up_connection.Count < count_of_up_connection || count_of_up_connection == -1;
            }
        }

        protected Operators()
        {
            index_of_Operator = count_of_operator4s_index++;
        }

        public List<Working_data> up_Conection
        {
            get
            {
                return up_connection;
            }
        }

        public Working_data up_Conected
        {
            set
            {
                if (up_connection.Count < count_of_up_connection)
                {
                    up_connection.Add(value);
                }
            }
        }

        public void If_operator_conected(if_operator if_)
        {
            if_Operators.Add(if_);
        }

        public override bool isDelete
        {
            get
            {
                return base.isDelete && up_connection.Count == 0;
            }
        }

        public override void Delete()
        {
            base.Delete();
            while(up_connection.Count != 0)
            {
                up_connection.RemoveAt(0);
            }
        }

    }
}

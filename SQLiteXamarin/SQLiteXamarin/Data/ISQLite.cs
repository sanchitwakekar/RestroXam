﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteXamarin.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}

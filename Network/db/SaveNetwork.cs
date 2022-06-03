using Android.Content;
using Android.Database.Sqlite;
using Java.Nio;
using Microsoft.Data.Sqlite;
using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using Android.Database;
using Android.Runtime;
using AndroidX.AppCompat.App;

namespace NueralNetrwork.Network.db
{
    class SaveNetwork : SQLiteOpenHelper
    {
        private static string DATABASE_NAME = "network.db"; // название бд
        private static int VERSION = 1; // версия базы данных
        public static string TABLE = "network"; // название таблицы в бд
        public static string COLUMN_ID = "_id";
        public static string COLUMN_NAME = "name";
        public static string COLUMN_LINE_BIAS = "lineBias";
        public static string COLUMN_STOLB_BIAS = "stolbBias";
        public static string COLUMN_LINE_WEIGHTS0 = "lineWeights0";
        public static string COLUMN_LINE_WEIGHTS1 = "lineWeights1";
        public static string COLUMN_STOLB_WEIGHTS0 = "stolbWeights0";
        public static string COLUMN_STOLB_WEIGHTS1 = "stolbWeights1";
        public static string COLUMN_OUTPUT_VALUES = "outputValues";
        public static string COLUMN_HIDDEN_VALUES = "hiddenValues";
        public static string COLUMN_NUMBER_HIDDEN = "numberHidden";
        public static string COLUMN_NUMBER_CYCLE = "numberCycle";
        public static string COLUMN_NUMBER_LEARNING = "numberLearning";
        public static string COLUMN_NUMBER_ERROR = "numberError";
        private static List<Network> networks = new List<Network>();

        public static void add(Network network)
        {
            networks.Add(network);
        }

        public static List<Network> getListData()
        {
            return networks;
        }

        public static void saveNewNetwork(Network network)
        {
            network.setFlagName("network");
            network.setNameNetwork("network");
            add(network);
            SQLiteDatabase db = null;
            string cs = @"URI=file:C:\Users\Jano\Documents\test.db";
            double[] doublesHidden = network.getHiddenValues();
            double[] doubleOutput = network.getOutputValues();
            double[][] bias = network.getBias();
            double[][,] weights = network.getWeights();
            double[] lineBias = bias[0];
            double[] stolbBias = bias[1];
            if(network == null)
            {
                var connection = new Microsoft.Data.Sqlite.SqliteConnection();
                connection.Open();
                Microsoft.Data.Sqlite.SqliteCommand command = new Microsoft.Data.Sqlite.SqliteCommand();
                command.Connection = connection;
                command.CommandText = "CREATE TABLE network (" + COLUMN_ID
                                                    + " INTEGER PRIMARY KEY AUTOINCREMENT," + COLUMN_NAME
                                                    + " TEXT, " + COLUMN_NUMBER_HIDDEN + " INTEGER," +
                                                    COLUMN_NUMBER_LEARNING
                                                    + " REAL," + COLUMN_NUMBER_CYCLE + " INTEGER,"
                                                    + COLUMN_NUMBER_ERROR + " REAL," + COLUMN_HIDDEN_VALUES + " BLOB," +
                                                    COLUMN_OUTPUT_VALUES + " BLOB," +
                                                    COLUMN_LINE_BIAS + " BLOB," + COLUMN_STOLB_BIAS + " BLOB," +
                                                    COLUMN_LINE_WEIGHTS0 + " BLOB," + COLUMN_STOLB_WEIGHTS0 + " BLOB," +
                                                    COLUMN_LINE_WEIGHTS1 + " BLOB," + COLUMN_STOLB_WEIGHTS1 + " BLOB);";
                command.Parameters.Add(network.getNumberHiddenNeurons());
                command.Parameters.Add(doubleOutput);
                command.Parameters.Add(bias);
                command.Parameters.Add(weights);
                command.Parameters.Add(lineBias);
                command.Parameters.Add(stolbBias);
                command.ExecuteNonQuery();
                using var cmd = new Microsoft.Data.Sqlite.SqliteCommand();
                ContentValues values = new ContentValues();
                values.Put(COLUMN_NAME, network.getFlagName());
                values.Put(COLUMN_NUMBER_HIDDEN, network.getNumberHiddenNeurons());
                values.Put(COLUMN_NUMBER_LEARNING, network.getLearningRateFactor());
                values.Put(COLUMN_NUMBER_CYCLE, network.getNumberCycles());
                values.Put(COLUMN_NUMBER_ERROR, network.getError());
                command.ExecuteNonQuery();
                db.Insert(TABLE, null, values);
                db.Close();
            }
                
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL("CREATE TABLE network (" + COLUMN_ID
                                                + " INTEGER PRIMARY KEY AUTOINCREMENT," + COLUMN_NAME
                                                + " TEXT, " + COLUMN_NUMBER_HIDDEN + " INTEGER," +
                                                COLUMN_NUMBER_LEARNING
                                                + " REAL," + COLUMN_NUMBER_CYCLE + " INTEGER,"
                                                + COLUMN_NUMBER_ERROR + " REAL," + COLUMN_HIDDEN_VALUES + " BLOB," +
                                                COLUMN_OUTPUT_VALUES + " BLOB," +
                                                COLUMN_LINE_BIAS + " BLOB," + COLUMN_STOLB_BIAS + " BLOB," +
                                                COLUMN_LINE_WEIGHTS0 + " BLOB," + COLUMN_STOLB_WEIGHTS0 + " BLOB," +
                                                COLUMN_LINE_WEIGHTS1 + " BLOB," + COLUMN_STOLB_WEIGHTS1 + " BLOB);");
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS " + TABLE);
            OnCreate(db);
        }

        public SaveNetwork(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public SaveNetwork(Context context, string name, SQLiteDatabase.ICursorFactory factory, int version) : base(
            context, name, factory, version)
        {
        }

        public SaveNetwork(Context context, string name, SQLiteDatabase.ICursorFactory factory, int version,
            IDatabaseErrorHandler errorHandler) : base(context, name, factory, version, errorHandler)
        {
        }

        public SaveNetwork(Context context, string name, int version, SQLiteDatabase.OpenParams openParams) : base(
            context, name, version, openParams)
        {
        }
    }
}
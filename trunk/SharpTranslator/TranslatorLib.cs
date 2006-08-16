
using System;
using System.Data;
using Mono.Data.SqliteClient;
using System.IO;
using System.Collections;

namespace SharpTranslator
{
	
	public class TranslatorLib
	{
		static IDbConnection dbcon;
		static IDbCommand dbcmd;
		
		public TranslatorLib()
		{
		}
		
		public static void Connect()
		{
			string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "translator.db");
			string connectionString = "URI=file:" + path + ", version=3";
			dbcon = (IDbConnection) new SqliteConnection(connectionString);
			dbcon.Open();
			dbcmd = dbcon.CreateCommand();
       		
   		}
	
		public static void Disconnect()
		{
			dbcon.Close();
		}
	
		public static string Escape(string buffer)
		{
			char[] chars = buffer.ToCharArray();
			string outbuffer = "";
			foreach(char c in chars)
			{
				if (c == '\'')
					outbuffer += "\\'";
				else
					outbuffer += c;
			}
			return outbuffer;
		}
		
		public static void ImportI2E(string file)
		{
			// open db connection:
			Connect();
			// open disctionary file:
       		StreamReader tr = new StreamReader(file);
       		string line = "";
       		string word, translation;
       		string[] buffer;
       		string sql;
       		IDataReader reader = null;
			line = tr.ReadLine();
			while (line != null)
			{
            	buffer = line.Split(':');
       			word = buffer[0];
       			translation = buffer[1];
       			word = word.Trim();
       			//word = Escape(word);
       			translation = translation.Trim();
       			//translation = Escape(translation);
       			// insert from file to database:
       			sql = "INSERT INTO WORDS (sourcelang, targetlang, word, translation) ";
       			sql += "VALUES (31, 35, ";
       			sql += "\"" + word + "\"";
       			sql += "," + "\"" + translation + "\")";
       			dbcmd.CommandText = sql;
       			reader = dbcmd.ExecuteReader();
       			line = tr.ReadLine();
       		}
       		if (reader != null)
       			reader.Close();
       		reader = null;
       		dbcmd.Dispose();
       		dbcmd = null;
       		dbcon.Close();
       }
	
	
	public static IList SearchKey(string key, string source, string target)
	{
       ArrayList result = new ArrayList();
       string sql = "SELECT word, translation from words, languages l, languages a";
       sql += " where sourcelang = l.id and l.name = \"" + source+"\"";
       sql += " and targetlang = a.id and a.name = \"" + target + "\"";
       sql += " and word like \"" + key +"%\"";
       dbcmd.CommandText = sql;
       IDataReader reader = dbcmd.ExecuteReader();
       while(reader.Read()) {
            string word = reader.GetString (0);
            string translation = reader.GetString (1);
            result.Add(word);
            result.Add(translation);
       }
       // inverse search
       sql = "SELECT word, translation from words, languages l, languages a";
       sql += " where sourcelang = l.id and l.name = \"" + target+"\"";
       sql += " and targetlang = a.id and a.name = \"" + source + "\"";
       sql += " and translation like \"" + key +"%\"";
       dbcmd.CommandText = sql;
       reader = dbcmd.ExecuteReader();
       while(reader.Read()) {
            string word = reader.GetString (0);
            string translation = reader.GetString (1);
            result.Add(translation);
            result.Add(word);
       }
       reader.Close();
       reader = null;
       return result ;
	}

	public static IList SearchExpression(string key, string source, string target)
	{
       ArrayList result = new ArrayList();
       string sql = "SELECT expression, translation from expressions, languages l, languages a";
       sql += " where sourcelang = l.id and l.name = \"" + source+"\"";
       sql += " and targetlang = a.id and a.name = \"" + target + "\"";
       sql += " and expression like \"" + key +"%\"";
       dbcmd.CommandText = sql;
       IDataReader reader = dbcmd.ExecuteReader();
       while(reader.Read()) {
            string word = reader.GetString (0);
            string translation = reader.GetString (1);
            result.Add(word);
            result.Add(translation);
       }
       // inverse search
       sql = "SELECT expression, translation from expressions, languages l, languages a";
       sql += " where sourcelang = l.id and l.name = \"" + target+"\"";
       sql += " and targetlang = a.id and a.name = \"" + source + "\"";
       sql += " and translation like \"" + key +"%\"";
       dbcmd.CommandText = sql;
       reader = dbcmd.ExecuteReader();
       while(reader.Read()) {
            string word = reader.GetString (0);
            string translation = reader.GetString (1);
            result.Add(translation);
            result.Add(word);
       }
       reader.Close();
       reader = null;
       return result ;
	}
	
	public static IList LoadActiveLanguages()
	{
       ArrayList result = new ArrayList();
       string sql ="select  distinct(name), languages.id from words, languages where sourcelang = languages.id or targetlang=languages.id";
       dbcmd.CommandText = sql;
       IDataReader reader = dbcmd.ExecuteReader();
       while(reader.Read()) {
            result.Add(reader.GetString (0));
			result.Add(reader.GetString (1));           
       }
       return result;
    }

	public static IList LoadAllLanguages()
	{
       ArrayList result = new ArrayList();
       string sql ="select  name, id from languages";
       dbcmd.CommandText = sql;
       IDataReader reader = dbcmd.ExecuteReader();
       while(reader.Read()) {
            result.Add(reader.GetString(0));
            result.Add(reader.GetString(1));
       }
       return result;
    }
    
    public static void LearnWord(int slang, int tlang, string word, string translation)
    {
       string sql ="INSERT INTO WORDS (sourcelang, targetlang, word, translation)";
       sql += " VALUES (" + slang +","+tlang+", \""+word+"\",\""+translation+"\")";
       dbcmd.CommandText = sql;
       dbcmd.ExecuteNonQuery();
    }

    public static void LearnExpression(int slang, int tlang, string expression, string translation)
    {
       string sql ="INSERT INTO EXPRESSIONS (sourcelang, targetlang, expression, translation)";
       sql += " VALUES (" + slang +","+tlang+", \""+expression+"\",\""+translation+"\")";
       dbcmd.CommandText = sql;
       dbcmd.ExecuteNonQuery();
    }
    
}	
	
}

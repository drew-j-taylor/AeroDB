using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AeroDB.Model;
using MySql.Data.MySqlClient;

namespace AeroDB.Service
{
    public class PartService
    {
        Part _part;
        ObservableCollection<string> programs = new ObservableCollection<string>();
        ObservableCollection<string> sources = new ObservableCollection<string>();

        public PartService() { }
        public async Task<Part> GetPart(string partNum)
        {
            string sql = "CALL aerodb.part_info(@partNum);";

            MySqlCommand cmd = new MySqlCommand(sql, App.Conn);
            cmd.Parameters.AddWithValue("@partNum", partNum);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (!rdr.HasRows)
            {
                rdr.Close();
                return null;
            }

            while (rdr.Read())
            {
                _part = new Part();
                _part.PartNumber = $"{rdr[0]}";
                _part.PartDescription = $"{rdr[1]}";
                _part.ProgramCode = $"{rdr[2]}";
                _part.SourceCode = $"{rdr[3]}";
            }
            rdr.Close();
            return _part;
        }
        public int EditPart(string partNum, string partDesc, string prog, string src)
        {
            string sql = "UPDATE aerodb.part SET part.partDescription = @partDescription, part.programID = (SELECT programID FROM aerodb.program WHERE programCode = @prog), part.sourceID = (SELECT sourceID FROM aerodb.source WHERE sourceCode = @source) WHERE part.partNum = @partNum;";

            MySqlCommand cmd = new MySqlCommand(sql, App.Conn);
            cmd.Parameters.AddWithValue("@partNum", partNum);
            cmd.Parameters.AddWithValue("@partDescription", partDesc);
            cmd.Parameters.AddWithValue("@prog", prog);
            cmd.Parameters.AddWithValue("@source", src);

            int editSuccess = cmd.ExecuteNonQuery();
            return editSuccess;
        }

        public int AddPart(string partNum, string partDesc, string prog, string src)
        {
            if (partNum == "" || partDesc == "" || prog == "" || src == "") { return -1; }

            string sql = "INSERT INTO aerodb.part (partNum, partDescription, programID, sourceID) VALUES (@partNum,@partDescription,(SELECT programID FROM aerodb.program WHERE programCode = @prog),(SELECT sourceID FROM aerodb.source WHERE sourceCode = @source));";

            MySqlCommand cmd = new MySqlCommand(sql, App.Conn);
            cmd.Parameters.AddWithValue("@partNum", partNum);
            cmd.Parameters.AddWithValue("@partDescription", partDesc);
            cmd.Parameters.AddWithValue("@prog", prog);
            cmd.Parameters.AddWithValue("@source", src);


            int addSuccess = cmd.ExecuteNonQuery();
            return addSuccess;
        }

        public ObservableCollection<string> GetPrograms()
        {
            
            string sql = "SELECT program.programCode FROM aerodb.program;";

            MySqlCommand cmd = new MySqlCommand(sql, App.Conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (!rdr.HasRows)
            {
                rdr.Close();
                return null;
            }

            while (rdr.Read())
            {
                programs.Add($"{rdr[0]}");
            }
            rdr.Close();
            return programs;
        }
        public ObservableCollection<string> GetSource()
        {
            string sql = "SELECT source.sourcecode FROM aerodb.source;";

            MySqlCommand cmd = new MySqlCommand(sql, App.Conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (!rdr.HasRows)
            {
                rdr.Close();
                return null;
            }

            while (rdr.Read())
            {
                sources.Add($"{rdr[0]}");
            }
            rdr.Close();
            return sources;
        }
    }
}

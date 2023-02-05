using Microsoft.Data.SqlClient;
using PurcheseWork.Helper;
using System.Data;
using static PurcheseWork.DTO.CommonDTO;


namespace PurcheseWork.StoreProcedurce
{
    public class PurcheseSpCommon
    {
        string Con = "Server=DESKTOP-8QUNF3O;Database=PurcheseOrderDB;Trusted_Connection=True;MultipleActiveResultSets=true";
    

        DataTable dt = new DataTable();
        public async Task<MessageHelper> EmployeeCreate(PartnerViewModel obj)
        {
            try
            {
                MessageHelper msg = new MessageHelper();
                using (var connection = new SqlConnection("Con"))
                {
                    
                    string sql = "spPartnerCreate";
                    using (SqlCommand sqlCmd = new SqlCommand(sql, connection))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@StrPartnerName", obj.StrPartnerName);
                        sqlCmd.Parameters.AddWithValue("@StrPartnerName", obj.IntPartnerTypeId);
                        sqlCmd.Parameters.AddWithValue("@IsActive", obj.IsActive);

                        connection.Open();
                        using (var sqlAdapter = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdapter.Fill(dt);
                        }
                        connection.Close();

                        msg.Message = "Created Successfully";
                        msg.statuscode = 200;
                        return msg;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

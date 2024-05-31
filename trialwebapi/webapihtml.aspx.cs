using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace trialwebapi
{
    public partial class webapihtml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Your API response string
                string jsonResponse = "[{\"Id\":1,\"Name\":\"Akash Srivastava\"},{\"Id\":2,\"Name\":\"Monika Srivastava\"},{\"Id\":3,\"Name\":\"Srivastava Ravi\"},{\"Id\":4,\"Name\":\" Srivastava\"},{\"Id\":5,\"Name\":\"Pankaj Srivastava\"}]";

                // Deserialize JSON string into a list of Person objects
                List<Person> people = JsonConvert.DeserializeObject<List<Person>>(jsonResponse);

                // Bind the list to a GridView
                GridView1.DataSource = people;
                GridView1.DataBind();
            }
        }

        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            
        }
    }
}
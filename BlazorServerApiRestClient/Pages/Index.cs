using BlazorServerApiRestClient.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerApiRestClient.Pages
{
    public partial class Index
    {
        List<Donacion> donaciones = new List<Donacion>();

        private async Task GetDonaciones()
        {
            donaciones = await Http.GetJsonAsync<List<Donacion>>("http://www.apidonaciones.somee.com/api/Donacion");
        }
    }
}

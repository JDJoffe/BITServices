<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="BitServicesWebApp.Pages.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: #eeeeee; padding-bottom: 10%">
        <section style="background-color: #282828; padding-top: 50px;">
            <center>
                <h1 class="text-light">Contact
                    <img width="100px" src="../Images/BIT-logos1.png" />IT services </h1>
                <h2 class="text-light">Have an Issue? Contact us</h2>
            </center>

        </section>
        <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-6" style="margin-left:20px">
                    <address class="text-dark">
                        One Microsoft Way<br />
                        Redmond, WA 98052-6399<br />
                        <abbr title="Phone">P:</abbr>
                        425.555.0100
   
                    </address>
                    

                    <address class="text-dark">
                        <strong>Support:</strong>   <a href="mailto:Support@BITServices.com">Support@BITServices.com</a><br />
                        <strong>Associations:</strong> <a href="mailto:Marketing@BITPartners.com">Partnetships@BITPartners.com</a>
                    </address>
                </div>
                <div class="col-5">
                     <center>
                            <img width="250px" src="../Images/sadman.jpg" style="margin-bottom: 20px;" />                        
                        </center>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

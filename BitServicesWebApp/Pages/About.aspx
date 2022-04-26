<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="BitServicesWebApp.Pages.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: #eeeeee; padding-bottom:10% ">
        <section style="background-color:#282828; padding-top:50px;">
            <center>
                <h1 class="text-light">Who is <img width="100px" src="../Images/BIT-logos1.png" />IT services? </h1>
               
            </center>

        </section>
        <div class="container" style="padding-top: 50px;">
           
                <div class="row">
                    <div class="col-20">
                        <center>
                            <h2 class="text-dark">BIT Services is a subdivision of Business Information Technology Pty Ltd</h2>
                            <h3 class="text-dark" style="padding: 20px"><b>We provide IT support services ranging from:</b></h3>
                        </center>
                    </div>
                </div>
             <center>
                <div class="row" style="align-content:center; padding-bottom:20px;">
                    <div class="col-5" style="padding-bottom: 20px;">
                        <center>
                            <img width="250px" src="../Images/tech.jpg" style="margin-bottom: 20px;" />
                            <h4 class="text-dark">Hardware & Software troubleshooting</h4>

                        </center>
                    </div>
                    <div class="col-5" style="padding-bottom: 20px;">
                        <center>
                            <img width="250px" src="../Images/instal.jpg" style="margin-bottom: 20px;" />
                            <h4 class="text-dark">New Installations</h4>

                        </center>
                    </div>
                    <div class="col-5" style="padding-bottom: 20px;">
                        <center>
                            <img width="250px" src="../Images/sadman.jpg" style="margin-bottom: 20px;" />
                            <h4 class="text-dark">Training for new technologies</h4>

                        </center>
                    </div>
                    <div class="col-5" style="padding-bottom: 20px;">
                        <center>
                            <img width="180px" src="../Images/rev-person-img.png" style="margin-bottom: 20px;" />
                            <h4 class="text-dark">And more</h4>

                        </center>
                    </div>
                </div>
            </center>
        </div>
    </div>
</asp:Content>

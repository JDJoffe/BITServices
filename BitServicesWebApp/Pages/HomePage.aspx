<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="BitServicesWebApp.Pages.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: #282828; padding-bottom: 20%">

        <div style="background-color: #eeeeee; background-image: url('../Images/BITBanner.png'); height: 600px; margin-left: -30%;" class="border-bottom">

            <center>
                <div style="margin-left: 23%; padding-top:7%">
                    <h1 class="text-light" style="font-size:40">Welcome to BIT Services</h1>
                    <p class="text-light"><b>See Our 3 Primary Features</b></p>
                </div>

            </center>
        </div>
        <section style="padding-top: 5%;">
        </section>
        <div class="container " style="padding-bottom: 80px; ">
            <div class="row">
                <div class="col-12">
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <center>
                        <img width="200px" src="../Images/Book.png" />
                        <h4 class="text-light">Book Online</h4>
                        <p class="text-justify text-light">
                            Book a job request and a contractor will fix your issue.
                        </p>
                    </center>
                </div>
                <div class="col-4">
                    <center>
                        <img width="200px" src="../Images/Search.png" />
                        <h4 class="text-light">Search Contractors</h4>
                        <p class="text-justify text-light">
                            Search contractors based on their skills.
                        </p>
                    </center>
                </div>
                <div class="col-4">
                    <center>
                        <img width="200px" src="../Images/Notify.png" />
                        <h4 class="text-light">Mobile Notifications</h4>
                        <p class="text-justify text-light">
                            Be notified when a contractor has accepted your request.
                        </p>
                    </center>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

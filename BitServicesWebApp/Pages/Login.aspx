<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BitServicesWebApp.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: #eeeeee; padding-bottom: 10%">
        <div id="container">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <img width="150px" src="../Images/BITlogin.png" />
                                    </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h3>User Login</h3>
                                    </center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <hr />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col">
                                    <label>UserName</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="userNameTxt" placeholder="Username" runat="server">
                                        </asp:TextBox>
                                    </div>
                                    <label>Password</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="passwordTxt" placeholder="Password" TextMode="Password" runat="server">
                                        </asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button CssClass="btn btn-success btn-block btn-lg" runat="server" Text="Login" ID="loginBtn" OnClick="loginBtn_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="background-color: #eeeeee; padding-bottom: 10%">
</asp:Content>


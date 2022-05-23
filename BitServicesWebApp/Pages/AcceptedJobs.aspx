<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcceptedJobs.aspx.cs" Inherits="BitServicesWebApp.Pages.AcceptedJobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Accepted Contractor Jobs</h2>
    <div id="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150" src="../Images/Book.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Your Accepted Jobs</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">                       
                                <asp:GridView ID="gvAccJobs" CssClass="table table-striped table-bordered" runat="server" OnRowCommand="gvAccJobs_RowCommand" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Distance">
                                            <ItemTemplate>
                                                <asp:TextBox ID="distanceTxt" runat="server" Height="40px" Width="80px" CommandName="Distance" CommandArgument="<%#Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FeedBack">
                                            <ItemTemplate>
                                                <asp:TextBox ID="feedBackTxt" runat="server" Height="40px" Width="80px" CommandName="Feedback" CommandArgument="<%#Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>                                      
                                        <asp:TemplateField HeaderText="Complete Job">
                                            <ItemTemplate>
                                                <asp:Button ID="completeBtn" runat="server" Height="40px" Width="80px" Text="Complete" CommandName="Complete" CommandArgument="<%#Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

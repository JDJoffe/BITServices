<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractorJobs.aspx.cs" Inherits="BitServicesWebApp.Pages.ContractorJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>Assigned Contractor Jobs</h2>
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
                                    <h3>your Assigned Jobs</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView 
                                    ID="gvJobs"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" 
                                    OnRowCommand="gvJobs_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Accept Job">
                                            <ItemTemplate>
                                                <asp:Button ID="acceptBtn" runat="server" Height="40px" Width="80px" Text="Accept" CommandName="Accept" CommandArgument="<%#Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Reject Job">
                                            <ItemTemplate>
                                                <asp:Button ID="rejectBtn" runat="server" Height="40px" Width="80px" Text="Reject" CommandName="Reject" CommandArgument="<%#Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText ="Feedback">
                                            <ItemTemplate>
                                                <asp:TextBox ID="feedBackTxt" runat="server" Height="40px" Width="200px" Text="" CommandName="Submit" CommandArgument="<%#Container.DataItemIndex %>" />
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


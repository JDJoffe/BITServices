<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllUnassignedJobs.aspx.cs" Inherits="BitServicesWebApp.Pages.AllUnassignedJobs" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
 <h2>All Client Job Requests</h2>
    <div id="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150" src="../Images/book.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>All Client Job Requests</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">                       
                                <asp:GridView ID="gvUnassignedJobs" CssClass="table table-striped table-bordered" runat="server" OnRowCommand="gvUnassignedJobs_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Approve Action">
                                            <ItemTemplate>
                                                <asp:Button ID="approveBtn" runat="server" Height="40px" Width="80px" Text="Assign" CommandName="Approve" CommandArgument="<%#Container.DataItemIndex %>" />
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

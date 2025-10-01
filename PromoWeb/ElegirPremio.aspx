<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Master.Master" CodeBehind="ElegirPremio.aspx.cs" Inherits="PromoWeb.ElegirPremio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="text-center my-4">Elegí tu premio</h2>

    <div class="row">
        <asp:Repeater ID="repArticulos" runat="server"
            OnItemDataBound="repArticulos_ItemDataBound"
            OnItemCommand="repArticulos_ItemCommand">

            <ItemTemplate>
                <!-- 3 columnas por fila -->
                <div class="col-md-4 mb-4 d-flex">
                    <div class="card h-100 shadow-sm text-center w-100">

                        <!-- Carrusel por artículo (ID único por artículo) -->
                        <div id='carousel_<%# Eval("Id") %>' class="carousel slide p-3" data-bs-ride="carousel">
                            <div class="carousel-inner">
                                <asp:Repeater ID="repImagenes" runat="server">
                                    <ItemTemplate>
                                        
                                        <div id="divItem" runat="server" class="carousel-item">
                                            <!-- Imagen más chica, centrada y proporcional -->
                                            <img src='<%# Container.DataItem %>' 
                                                 class="img-fluid mx-auto d-block"
                                                 style="max-height:200px;" 
                                                 alt="Imagen" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <!-- Controles del carrusel -->
                            <button class="carousel-control-prev" type="button" data-bs-target='#carousel_<%# Eval("Id") %>' data-bs-slide="prev">
                                <span class="carousel-control-prev-icon"></span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target='#carousel_<%# Eval("Id") %>' data-bs-slide="next">
                                <span class="carousel-control-next-icon"></span>
                            </button>
                        </div>

                        <!-- Título y descripción -->
                        <div class="card-body">
                            <h5 class="card-title mb-1"><%# Eval("Nombre") %></h5>
                            <p class="card-text text-muted"><%# Eval("Descripcion") %></p>
                        </div>

                        <!-- Botón -->
                        <div class="card-footer bg-white">
                            <asp:Button ID="btnElegir" runat="server" 
                                CssClass="btn btn-primary w-100"
                                Text="Quiero este!" 
                                CommandName="Elegir" 
                                CommandArgument='<%# Eval("Id") %>' />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
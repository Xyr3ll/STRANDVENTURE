// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Apply STRANDVENTURE DataTables defaults when DataTables is available
window.applyDataTablesDefaults = function () {
    if (!window.DataTable || window.__dtDefaultsApplied) return;

    // Layout: length + search on top, info + paging bottom
    DataTable.defaults.layout = {
        topStart: 'pageLength',
        topEnd: 'search',
        bottomStart: 'info',
        bottomEnd: 'paging'
    };

    // Language polish
    DataTable.defaults.language = Object.assign({}, DataTable.defaults.language, {
        searchPlaceholder: 'Search...',
        lengthMenu: '_MENU_ per page'
    });

    // Reasonable defaults
    DataTable.defaults.pageLength = 10;
    DataTable.defaults.ordering = true;

    window.__dtDefaultsApplied = true;
};

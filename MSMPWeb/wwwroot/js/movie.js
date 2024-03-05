var dataTable;
$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/movie/getall' },
        "columns": [
            { data: 'title', "width": "20%" },
            {
                data: 'releaseDate',
                "width": "10%",
                "render": function (data) {
                    // Parse the date string
                    const releaseDate = new Date(data);

                    // Extract day, month, and year components
                    const day = releaseDate.getDate();
                    const monthIndex = releaseDate.getMonth();
                    const year = releaseDate.getFullYear();

                    // Array of month names
                    const monthNames = [
                        "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
                    ];

                    // Construct the date string in the desired format
                    const dateString = `${day} ${monthNames[monthIndex]} ${year}`;
                    return dateString;
                }
            },
            { data: 'genre', "width": "5%" },
            {
                data: 'duration', "width": "5%",
                "render": function (data) {
                    return `${data} min`;
                }
            },
            {
                data: 'rating', "width": "5%",
                "render": function (data) {
                    return `${data} %`;
                },

            },
            { data: 'description', "width": "35%" },
            {
                data: 'imageUrl', "width": "20%",
                "render": function (data) {
                    return `<img src="${data.substring(1)}" style="width: 100px; height: auto;" />`;
                }
            }
        ]
    });
}


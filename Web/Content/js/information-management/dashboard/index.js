var page = new Page("/InformationManagement/Dashboard");


$(function () {
    var ctx = document.getElementById('myChart');
    ctx.height = 100
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['DRCN Report', 'Masterlist of Documents', 'Registration for External Document', 'List of Departmental Records', 'Records for Transfer and Disposal Form'],

            datasets: [{
                label: '',
                data: [7, 12, 12, 18, 20],
                backgroundColor: [
                    'rgba(78,115,223, 0.2)',
                    'rgba(28,200,138, 0.2)',
                    'rgba(54,185,204, 0.2)',
                    'rgba(246, 194, 62, 0.2)',
                    'rgba(239, 60, 71, 0.2)'
                ],
                borderColor: [
                    'rgba(78,115,223, 1)',
                    'rgba(28,200,138, 1)',
                    'rgba(54,185,204, 1)',
                    'rgba(246, 194, 62, 1)',
                    'rgba(196, 60, 71, 1)'
                ],
                borderWidth: 1
            }

            ]
        },
        options: {
            plugins: {
                legend: {
                    display: false
                }
            },
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });



});



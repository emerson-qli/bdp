var page = new Page("/RiskMangement/Dashboard");


$(function () {
    var ctx = document.getElementById('myChart');
    ctx.height = 100
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Item 1', 'Item 2', 'Item 3', 'Item 4'],

            datasets: [{
                label: '',
                data: [40, 215, 50, 18],
                backgroundColor: [
                    'rgba(78,115,223, 0.2)',
                    'rgba(28,200,138, 0.2)',
                    'rgba(54,185,204, 0.2)',
                    'rgba(246, 194, 62, 0.2)'
                ],
                borderColor: [
                    'rgba(78,115,223, 1)',
                    'rgba(28,200,138, 1)',
                    'rgba(54,185,204, 1)',
                    'rgba(246, 194, 62, 1)'
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



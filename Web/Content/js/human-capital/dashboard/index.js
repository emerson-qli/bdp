var page = new Page("/HumanCapital/Dashboard");


$(function () {
    var ctx = document.getElementById('myChart');
    ctx.height = 100
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: ['Departments', 'Positions', 'Employees'],

            datasets: [{
                label: '',
                data: [5, 5, 21],
                backgroundColor: [
                    'rgba(78,115,223, 0.2)',
                    'rgba(28,200,138, 0.2)',
                    'rgba(54,185,204, 0.2)'
                ],
                borderColor: [
                    'rgba(78,115,223, 1)',
                    'rgba(28,200,138, 1)',
                    'rgba(54,185,204, 1)'
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



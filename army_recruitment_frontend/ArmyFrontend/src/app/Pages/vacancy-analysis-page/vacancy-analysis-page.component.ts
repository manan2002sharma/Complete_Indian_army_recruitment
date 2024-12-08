import { Component, Input, OnInit } from '@angular/core';
import { VacancyService } from '../../Services/vacancy.service';
import {
  Chart,
  BarController,
  BarElement,
  CategoryScale,
  LinearScale,
  Title,
  Tooltip,
  Legend,
} from 'chart.js';
import { ActivatedRoute, Router } from '@angular/router';

Chart.register(BarController, BarElement, CategoryScale, LinearScale, Title, Tooltip, Legend);

@Component({
  selector: 'app-vacancy-analysis-page',
  standalone: true,
  imports: [],
  templateUrl: './vacancy-analysis-page.component.html',
  styleUrl: './vacancy-analysis-page.component.css'
})
export class VacancyAnalysisPageComponent implements OnInit {
  reportData: any = {};
  resultAnalysisData: any[] = [];
  successRate: number = 0;
  statusData: any[] = [];
  statesData: any[] = [];
  vacancyId : string = '';

  // reportData: any = {
  //   reportId: '00000000-0000-0000-0000-000000000000',
  //   vacancyId: '93a61557-e432-4638-3084-08dd1526421c',
  //   vacancyName: 'Mock Vacancy',
  //   dateGenerated: '2024-12-05T17:43:41.8470348',
  //   postedBy: 'Admin',
  // };
  // resultAnalysisData: any[] = [
  //   { examDate: '2024-12-10', passPercentage: 90 },
  //   { examDate: '2024-12-13', passPercentage: 85 },
  // ];
  // successRate: number = 88;
  // statusData: any[] = [
  //   { status: 'Active', count: 3 },
  //   { status: 'Closed', count: 1 },
  // ];
  // statesData: any[] = [
  //   { stateName: 'State A', totalCandidates: 10 },
  //   { stateName: 'State B', totalCandidates: 15 },
  // ];

  constructor(private vacancyAnalysisService: VacancyService , private route : ActivatedRoute) {}

  ngOnInit(): void {
    

    this.loadVacancyAnalysis();
  }

  loadVacancyAnalysis(): void {
    
    this.route.queryParams.subscribe(params => {
      this.vacancyId= params['vacancyId'];
      console.log('Vacancy ID:', this.vacancyId); // Now you can use the vacancyId
    });
    this.vacancyAnalysisService.getVacancyAnalysis(this.vacancyId).subscribe((data) => {
      this.reportData = data;
      this.resultAnalysisData = data.resultAnalysis;
      this.successRate = data.successRate;
      this.statusData = data.status;
      this.statesData = data.states;

      this.createResultAnalysisChart();
      this.createStatusChart();
      this.createStatesChart();
    });
    console.log(this.reportData);
  }

  createResultAnalysisChart(): void {
    const labels = this.resultAnalysisData.map((item: any) => item.examName);
    const data = this.resultAnalysisData.map((item: any) => item.passPercentage);
    console.log(labels,data);
    new Chart('resultAnalysisChart', {
      type: 'bar',
      data: {
        labels: labels,
        datasets: [
          {
            label: 'Pass Percentage',
            data: data,
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1,
          },
        ],
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }

  createStatusChart(): void {
    const labels = this.statusData.map((item: any) => item.status);
    const data = this.statusData.map((item: any) => item.count);

    new Chart('statusChart', {
      type: 'bar',
      data: {
        labels: labels,
        datasets: [
          {
            label: 'Status Count',
            data: data,
            backgroundColor: 'rgba(255, 99, 132, 0.2)',
            borderColor: 'rgba(255, 99, 132, 1)',
            borderWidth: 1,
          },
        ],
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }

  createStatesChart(): void {
    const labels = this.statesData.map((item: any) => item.stateName);
    const data = this.statesData.map((item: any) => item.totalCandidates);

    new Chart('statesChart', {
      type: 'bar',
      data: {
        labels: labels,
        datasets: [
          {
            label: 'Total Candidates',
            data: data,
            backgroundColor: 'rgba(54, 162, 235, 0.2)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1,
          },
        ],
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }

  // createResultAnalysisChart() {
  //   new Chart('resultAnalysisChart', {
  //     type: 'bar',
  //     data: {
  //       labels: this.resultAnalysisData.map(item => item.examDate),
  //       datasets: [
  //         {
  //           label: 'Pass Percentage',
  //           data: this.resultAnalysisData.map(item => item.passPercentage),
  //           backgroundColor: 'rgba(75, 192, 192, 0.6)',
  //           borderColor: 'rgba(75, 192, 192, 1)',
  //           borderWidth: 1
  //         }
  //       ]
  //     },
  //     options: {
  //       responsive: true,
  //       plugins: {
  //         legend: {
  //           display: true
  //         }
  //       }
  //     }
  //   });
  // }

  // createStatusChart() {
  //   new Chart('statusChart', {
  //     type: 'bar',
  //     data: {
  //       labels: this.statusData.map(item => item.status),
  //       datasets: [
  //         {
  //           label: 'Count',
  //           data: this.statusData.map(item => item.count),
  //           backgroundColor: 'rgba(255, 99, 132, 0.6)',
  //           borderColor: 'rgba(255, 99, 132, 1)',
  //           borderWidth: 1
  //         }
  //       ]
  //     },
  //     options: {
  //       responsive: true,
  //       plugins: {
  //         legend: {
  //           display: true
  //         }
  //       }
  //     }
  //   });
  // }

  // createStatesChart() {
  //   new Chart('statesChart', {
  //     type: 'bar',
  //     data: {
  //       labels: this.statesData.map(item => item.stateName),
  //       datasets: [
  //         {
  //           label: 'Total Candidates',
  //           data: this.statesData.map(item => item.totalCandidates),
  //           backgroundColor: 'rgba(54, 162, 235, 0.6)',
  //           borderColor: 'rgba(54, 162, 235, 1)',
  //           borderWidth: 1
  //         }
  //       ]
  //     },
  //     options: {
  //       responsive: true,
  //       plugins: {
  //         legend: {
  //           display: true
  //         }
  //       }
  //     }
  //   });
  // }
}

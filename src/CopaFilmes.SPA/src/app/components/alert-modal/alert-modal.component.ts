import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-alert-modal',
  templateUrl: './alert-modal.component.html'
})
export class AlertModalComponent implements OnInit {
    @Input() mensagem: string;
  @Input() tipoAlerta = 'warning';
  constructor() { }

  ngOnInit(): void {
  }

}

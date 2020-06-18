import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-arlet-modal',
  templateUrl: './arlet-modal.component.html',
  styleUrls: ['./arlet-modal.component.css']
})
export class ArletModalComponent implements OnInit {
  @Input() mensagem: string;
  @Input() tipoAlerta = 'warning';
  constructor() { }

  ngOnInit(): void {
  }

}

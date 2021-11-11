package com.soa.service.purchase.model.domain;

import java.time.LocalDateTime;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class Reserva {
	private Integer reservaId;
	private int cantidadPersonas;
	private String fechaInicio;
	private String fechaFin;
	private String titulo;
	private Double precio;
	private Double duracion;
	private LocalDateTime fecha;
	private int estado;
}

package com.soa.service.booking.model.dto.response;

import java.time.LocalDateTime;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;


@Getter
@Setter
@Builder
@AllArgsConstructor
@NoArgsConstructor
public class ReservaCompleteDTO {

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

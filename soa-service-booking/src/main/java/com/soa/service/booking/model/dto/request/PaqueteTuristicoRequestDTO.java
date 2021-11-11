package com.soa.service.booking.model.dto.request;

import java.time.LocalDateTime;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
public class PaqueteTuristicoRequestDTO {
	private Integer paqueteId;
	private String titulo;
	private String descripcion;
	private Double precio;
	private Double duracion;
	private LocalDateTime fecha;
	private int estado;
}

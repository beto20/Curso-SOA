package com.soa.service.purchase.model.dto;

import java.time.LocalDateTime;

import com.soa.service.purchase.model.domain.Estado;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class CompraResponseDTO {
	private Integer compraId;
	private Integer reservaId;
	private int cantidadPersonas;
	private String fechaInicio;
	private String fechaFin;
	private String titulo;
	private Double precio;
	private Double duracion;
	private LocalDateTime fecha;
	private Estado estado;	
}

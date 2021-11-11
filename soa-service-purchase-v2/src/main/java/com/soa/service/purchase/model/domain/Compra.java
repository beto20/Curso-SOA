package com.soa.service.purchase.model.domain;

import java.io.Serializable;

import javax.persistence.Entity;
import javax.persistence.EnumType;
import javax.persistence.Enumerated;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;


import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Builder
@Entity
@Table(name="tabla_compra")
public class Compra implements Serializable {

	private static final long serialVersionUID = 5458208535357399672L;
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Integer compraId;
	
	private Integer reservaId;
	
	@Enumerated(EnumType.STRING)
	private Estado estado;	
}

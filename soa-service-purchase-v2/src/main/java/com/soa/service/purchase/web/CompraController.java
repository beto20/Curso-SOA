package com.soa.service.purchase.web;

import java.util.List;

import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.soa.service.purchase.business.CompraBusiness;
import com.soa.service.purchase.model.domain.Compra;
import com.soa.service.purchase.model.dto.CompraResponseDTO;

import lombok.RequiredArgsConstructor;



@RestController
@RequestMapping("compras")
@RequiredArgsConstructor
public class CompraController {
	
	private final CompraBusiness business;
	
	@GetMapping
	public List<Compra> listarCompras() {
		return business.listar();
	}
	
	@PostMapping
	public Compra procesarCompra(@RequestBody Compra compra) throws Exception {
		return business.procesar(compra);
	}
	
	@DeleteMapping("/{id}")
	public void cancelarCompra(@PathVariable("id") Integer id) {
		business.cancelar(id);
	}
	
	@GetMapping("/{id}")
	public CompraResponseDTO verCompra(@PathVariable("id") Integer id) {
		return business.compraPorId(id);
	}
}

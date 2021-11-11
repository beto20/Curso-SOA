package com.soa.service.purchase.business;

import java.util.List;

import com.soa.service.purchase.model.domain.Compra;
import com.soa.service.purchase.model.dto.CompraResponseDTO;

public interface CompraBusiness {
	public List<Compra> listar();
	public Compra procesar(Compra compra) throws Exception;
	public void cancelar(Integer id);
	public CompraResponseDTO compraPorId(Integer id);
}

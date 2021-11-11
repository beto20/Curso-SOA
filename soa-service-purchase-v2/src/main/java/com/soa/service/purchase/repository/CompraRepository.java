package com.soa.service.purchase.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.soa.service.purchase.model.domain.Compra;

@Repository
public interface CompraRepository extends JpaRepository<Compra, Integer> {

}

package hr.algebra.dao;

import hr.algebra.dao.sql.HibernateRepository;

public class RepositoryFactory {
    private static final Repository REPOSITORY = new HibernateRepository();
    
    private RepositoryFactory() {}
    
    public static Repository getRepository() {
        return REPOSITORY;
    }
}

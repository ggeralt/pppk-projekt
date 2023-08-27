package hr.algebra.dao.sql;

import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class HibernateFactory {
    public static final String SELECT_PEOPLE = "Person.findAll";
    public static final String SELECT_JOB = "Job.findAll";
    private static final String PERSISTENCE_UNIT = "PersonManagerPU";
    private static final EntityManagerFactory ENTITY_MANAGER_FACTORY = Persistence.createEntityManagerFactory(PERSISTENCE_UNIT);
    
    private HibernateFactory() {}
    
    public static EntityManagerWrapper getEntityManager() {
        return new EntityManagerWrapper(ENTITY_MANAGER_FACTORY.createEntityManager());
    }
    
    public static void release() {
        ENTITY_MANAGER_FACTORY.close();
    }
}

package hr.algebra.dao;

import hr.algebra.model.Person;
import java.util.List;

public interface Repository {
    int addPerson(Person data) throws Exception;
    void updatePerson(Person person) throws Exception;
    void deletePerson(Person person) throws Exception;
    Person getPerson(int idPerson) throws Exception;
    List<Person> getPeople() throws Exception;
    default void release() throws Exception {}
}

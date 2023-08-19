package hr.algebra.peoplemanager

import android.app.Application
import hr.algebra.peoplemanager.dao.PeopleDatabase
import hr.algebra.peoplemanager.dao.PersonDao

class App : Application() {
    private lateinit var personDao: PersonDao
    fun getPersonDao() = personDao

    override fun onCreate() {
        super.onCreate()
        var database = PeopleDatabase.getInstance(this)
        personDao = database.personDao()
    }
}
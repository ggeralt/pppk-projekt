package hr.algebra.peoplemanager.dao

import android.content.Context
import androidx.room.AutoMigration
import androidx.room.Database
import androidx.room.Room
import androidx.room.RoomDatabase
import androidx.room.TypeConverters

@Database(entities = [Person::class], version = 2, exportSchema = true, autoMigrations = [AutoMigration(from = 1, to = 2)])
@TypeConverters(DateConverter::class)
abstract class PeopleDatabase : RoomDatabase() {
    abstract fun personDao() : PersonDao

    companion object {
        @Volatile private var INSTANCE: PeopleDatabase? = null
        fun getInstance(context: Context) =
            INSTANCE ?: synchronized(PeopleDatabase::class.java) {
                INSTANCE ?: buildDatabase(context).also { INSTANCE = it }
            }

        private fun buildDatabase(context: Context) =
            Room.databaseBuilder(
                context.applicationContext,
                PeopleDatabase::class.java,
                "people.db"
            ).build()
    }
}
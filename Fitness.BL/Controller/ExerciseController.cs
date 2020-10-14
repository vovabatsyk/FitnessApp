﻿using System;
using System.Collections.Generic;
using System.Linq;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
    public class ExerciseController : BaseController
    {
        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user), "Empty User");
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }


        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.FirstOrDefault(a => a.Name == activity.Name);
            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }
        private List<Activity> GetAllActivities() => Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();

        private List<Exercise> GetAllExercises() => Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}

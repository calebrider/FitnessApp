# Fitness App API

- [Fitness App API](#fitness-app-api)
  - [Create Workout](#create-workout)
    - [Create Workout Request](#create-workout-request)
    - [Create Workout Response](#create-workout-response)
  - [Get Workout](#get-workout)
    - [Get Workout Request](#get-workout-request)
    - [Get Workout Response](#get-workout-response)
  - [Update Workout](#update-workout)
    - [Update Workout Request](#update-workout-request)
    - [Update Workout Response](#update-workout-response)
  - [Delete Workout](#delete-workout)
    - [Delete Workout Request](#delete-workout-request)
    - [Delete Workout Response](#delete-workout-response)

## Create Workout

### Create Workout Request

```js
POST /workouts
```

```json
{
    "name": "Legs",
    "description": "Leg day workout",
    "startDateTime": "2023-04-08T08:00:00",
    "endDateTime": "2023-04-08T09:00:00",
    "exercises": [
        "Squats",
        "Hamstring Curls",
        "Calf Raises"
    ]
}
```

### Create Workout Response

```js
201 Created
```

```yml
Location: {{host}}/Workouts/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Legs",
    "description": "Leg day workout",
    "startDateTime": "2023-04-08T08:00:00",
    "endDateTime": "2023-04-08T09:00:00",
    "lastModifiedDateTime": "2023-04-06T12:00:00",
    "exercises": [
        "Squats",
        "Hamstring Curls",
        "Calf Raises"
    ]
}
```

## Get Workout

### Get Workout Request

```js
GET /workouts/{{id}}
```

### Get Workout Response

```js
200 Ok
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Legs",
    "description": "Leg day workout",
    "startDateTime": "2023-04-08T08:00:00",
    "endDateTime": "2023-04-08T09:00:00",
    "lastModifiedDateTime": "2023-04-06T12:00:00",
    "exercises": [
        "Squats",
        "Hamstring Curls",
        "Calf Raises"
    ]
}
```

## Update Workout

### Update Workout Request

```js
PUT /workouts/{{id}}
```

```json
{
    "name": "Legs",
    "description": "Leg day workout",
    "startDateTime": "2023-04-08T08:00:00",
    "endDateTime": "2023-04-08T09:00:00",
    "lastModifiedDateTime": "2023-04-06T12:00:00",
    "exercises": [
        "Squats",
        "Hamstring Curls",
        "Calf Raises"
    ]
}
```

### Update Workout Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Workouts/{{id}}
```

## Delete Workout

### Delete Workout Request

```js
DELETE /workouts/{{id}}
```

### Delete Workout Response

```js
204 No Content
```